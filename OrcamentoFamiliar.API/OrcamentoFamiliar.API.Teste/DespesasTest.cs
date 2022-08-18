using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using OrcamentoFamiliar.API.Services;

namespace OrcamentoFamiliar.API.Teste
{
    public class DespesasTest
    {
        #region CONSTRUTOR
        private readonly IDespesaService _sut;
        // Mocks
        private readonly IMapper _mapper;
        private readonly Mock<IDespesasRepository> _despesasRepositoryMock;

        private Mapper GetMapper()
        {
            var config = AutoMapperConfig.RegisterMappings();
            return new Mapper(config);
        }

        public DespesasTest()
        {
            _mapper = GetMapper();
            _despesasRepositoryMock = new Mock<IDespesasRepository>();

            _sut = new DespesaService
            (
                _despesasRepositoryMock.Object,
                _mapper
            );
        }
        #endregion


        //public async Task GetDespesas_UsuarioFazRequisicao_RetornaListaDespesas()

        #region Create
        [Fact(DisplayName = "Create A Valid Despesa")]
        [Trait("Category", "Services")]
        public async Task Create_ValidDespesa_ReturnsDespesaDTO()
        {
            // Arrange
            var despesaDto = DespesaFakeData.CreateValidDespesasDTO();
            var despesasCreated = _mapper.Map<Despesas>(despesaDto);

            _despesasRepositoryMock.Setup(x => x.List(It.IsAny<string>()))
                .ReturnsAsync(() => default);

            _despesasRepositoryMock.Setup(x => x.Insert(It.IsAny<Despesas>()))
                .ReturnsAsync(() => despesasCreated);
            despesasCreated.Validate();

            // Act
            var act = await _sut.Create(despesaDto);
            // Assert
            act.Should().BeEquivalentTo(_mapper.Map<DespesaResponse>(despesasCreated));
        }

        [Fact(DisplayName = "Create When Despesa Already Added")]
        [Trait("Category", "Services")]
        public void Create_WhenDespesaAlreadyAdded_ThrowDomainException()
        {
            // Arrange
            var despesaDto = DespesaFakeData.CreateValidDespesasDTO();
            var despesaList = DespesaFakeData.CreateListValidDespesas();
            var despesa = _mapper.Map<Despesas>(despesaDto);

            despesaList[0] = despesa;

            // Act
            Func<Task<DespesaResponse>> act = async () => { return await _sut.Create(despesaDto); };
            //Assert
            act.Should().ThrowAsync<DomainException>();
        }

        [Fact(DisplayName = "Create When Despesa Already Exist But With Different Month")]
        [Trait("Category", "Services")]
        public async Task Create_WhenHasMonthDifferent_ReturnsDespesaDTO()
        {
            // Assert
            var despesaDto = DespesaFakeData.CreateValidDespesasDTO();
            var despesaList = DespesaFakeData.CreateListValidDespesas();
            var despesa = _mapper.Map<Despesas>(despesaDto);
            despesa.Data = new DateTime(2022, 01, 04);

            despesaList[0] = despesa;


            _despesasRepositoryMock.Setup(x => x.List(It.IsAny<string>()))
                .ReturnsAsync(() => despesaList);

            _despesasRepositoryMock.Setup(x => x.Insert(It.IsAny<Despesas>()))
                .ReturnsAsync(() => despesa);
            despesa.Validate();

            // Act
            var act = await _sut.Create(despesaDto);
            // Assert
            act.Should().BeEquivalentTo(_mapper.Map<DespesaResponse>(despesa));
        }

        [Fact(DisplayName = "Create When Despesa Already Exist But With Same Month")]
        [Trait("Category", "Services")]
        public void Create_WhenHasSameMonth_ThrowDomainException()
        {
            // Arrange
            var despesaDto = DespesaFakeData.CreateValidDespesasDTO();
            var despesaList = DespesaFakeData.CreateListValidDespesas();
            var despesa = _mapper.Map<Despesas>(despesaDto);

            despesa.Descricao = "SameThing";
            despesa.Data = new DateTime(2022, 01, 01);

            despesaList[0] = despesa;

            _despesasRepositoryMock.Setup(x => x.List(It.IsAny<string>()))
                .ReturnsAsync(() => despesaList);

            // Act
            Func<Task<DespesaResponse>> act = async () => { return await _sut.Create(despesaDto); };
            // Assert
            act.Should().ThrowAsync<DomainException>();
        }
        #endregion

        #region Update
        [Fact(DisplayName = "Update A Valid Despesa")]
        [Trait("Category", "Services")]
        public async Task Update_ValidDespesa_ReturnsDespesaDTO()
        {
            // Arrange
            var oldDespesa = DespesaFakeData.CreateValidDespesa();
            var despesaDto = DespesaFakeData.CreateValidDespesasDTO();
            var despesaUpdated = _mapper.Map<Despesas>(despesaDto);
            var list = DespesaFakeData.CreateListValidDespesas();

            _despesasRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(() => oldDespesa).Verifiable();

            _despesasRepositoryMock.Setup(x => x.List(It.IsAny<string>()))
                .ReturnsAsync(() => list).Verifiable();

            _despesasRepositoryMock.Setup(x => x.Update(It.IsAny<Despesas>()))
                .ReturnsAsync(() => despesaUpdated);

            despesaUpdated.Validate();
            // Act
            var act = await _sut.Update(despesaDto, oldDespesa.Id);
            // Assert
            act.Should().BeEquivalentTo(_mapper.Map<DespesaResponse>(despesaUpdated));
        }
        #endregion
    }
}
