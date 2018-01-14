var ViewModel = function () {
    var self = this;
    self.concursos = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    var concursosUri = '/api/concursos/';

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
            self.concursos(data);
        });
    }


    self.getConcursosDetail = function (item) {
        ajaxHelper(concursosUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    getAllConcursos();
};

ko.applyBindings(new ViewModel());