var ViewModel = function () {
    var self = this;
    self.concursos = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.janela = ko.observable('Concurso');

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

    self.getAllApostas = function (concurso) {
    
    };

    self.acaoApostar = function (item) {
        appLoteria.apostaCorrente = item.Id;
        appLoteria.janela = "Aposta";
        self.janela('Aposta');

        console.log(self.janela, appLoteria.apostaCorrente);
    };

    self.acaoResultado = function (item) {
        appLoteria.apostaCorrente = item.Id;

        console.log('acaoResultado');
        console.log(appLoteria.apostaCorrente);
    };

    self.acaoSortear = function (item) {
        appLoteria.apostaCorrente = item.Id;

        console.log('acaoSortear');
        console.log(appLoteria.apostaCorrente);
    };

    // Fetch the initial data.
    getAllConcursos();
};

ko.applyBindings(new ViewModel());