var ViewModel = function () {
    var self = this;
    self.concursos = ko.observableArray();
    self.apostas = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.concursoCorrente = 0;
    self.janela = ko.observable('Concurso');
    self.janelaNovaAposta = ko.observable('');
    self.novaAposta = {
        ConcursoId: ko.observable(),
        Jogo1: ko.observable(),
        Jogo2: ko.observable(),
        Jogo3: ko.observable(),
        Jogo4: ko.observable(),
        Jogo5: ko.observable(),
        Jogo6: ko.observable()
    }

    var concursosUri = '/api/concursos/';
    var apostasUri = '/api/apostas/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function formataData(d) {
        dt = d.split('T');
        dd = dt[0].split('-').reverse().join('/') + ' - ' + dt[1];
        return dd;
    }

    function getAllConcursos() {
        ajaxHelper(concursosUri, 'GET').done(function (data) {
            for (let c of data) {
                if (c.Sorteio[0] === 0) {
                    c.Sorteado = "N";
                } else {
                    c.Sorteado = "S";
                }
            }
            self.concursos(data);
        });
    }

    self.getConcursosDetail = function (item) {
        ajaxHelper(concursosUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    };

    self.getAllApostas = function () {
        ajaxHelper(concursosUri + self.concursoCorrente + '/apostas/', 'GET').done(function (data) {
            for (let a of data) {
                if (a.DataHora.length > 10) {
                    a.DataHora = formataData(a.DataHora);
                }
            }
            data.reverse()
            self.apostas(data);
        });
    };

    self.acaoApostar = function (item) {
        self.concursoCorrente = item.Id;
        self.janela('Aposta');
        self.getAllApostas();
    };

    self.acaoResultado = function (item) {
        appLoteria.concursoCorrente = item.Id;
    };

    self.acaoSortear = function (item) {
        appLoteria.concursoCorrente = item.Id;
    };

    self.acaoNovaAposta = function () {
        self.janelaNovaAposta('Ativa');
        self.novaAposta.ConcursoId(self.concursoCorrente);
        self.novaAposta.Jogo1(0);
        self.novaAposta.Jogo2(0);
        self.novaAposta.Jogo3(0);
        self.novaAposta.Jogo4(0);
        self.novaAposta.Jogo5(0);
        self.novaAposta.Jogo6(0);
    };

    self.acaoSalvarAposta = function () {
        let apostaDTO = {
            'ConcursoId': self.novaAposta.ConcursoId(),
            'Jogo': [self.novaAposta.Jogo1(), self.novaAposta.Jogo2(), self.novaAposta.Jogo3(), self.novaAposta.Jogo4(), self.novaAposta.Jogo5(), self.novaAposta.Jogo6()]
        }
        ajaxHelper(apostasUri, 'POST', apostaDTO).done(function (data) {  });
        self.acaoNovaAposta();
        self.getAllApostas();
    };

    self.acaoVoltarConcursos = function () {
        // Recarrega os concursos
        getAllConcursos();
        self.janelaNovaAposta('inativa');
        self.janela('Concurso');
    };

    // Fetch the initial data.
    getAllConcursos();
};

ko.applyBindings(new ViewModel());