app.controller('novoClienteCtrl', function ($scope, $rootScope, $location, $state, clientesAPIServices, $stateParams) {
    $scope.sp = $stateParams;
    $scope.loc = $location.$$url;

    $('.cpf').mask('000.000.000-00', {
        reverse: true
    });

    $scope.profissoes = [{
        "Id": 1,
        "Cargo": "Analista"
    }, {
        "Id": 2,
        "Cargo": "Gerente"
    }, {
        "Id": 3,
        "Cargo": "QA"
    }, {
        "Id": 4,
        "Cargo": "Estagiário"
    }, {
        "Id": 5,
        "Cargo": "Programador"
    }];

    $scope.idade = function () {
        let idade = $scope.cliente.nascimento
        let hoje = moment(new Date()).format('DD/MM/YYYY');
        let ms = moment(hoje, "DD/MM/YYYY").diff(moment(idade, "DD/MM/YYYY"));
        let d = moment.duration(ms);
        let idadeAtual = d._data.years;
        $scope.cliente.idade = idadeAtual;
    };

    if ($scope.loc != "/cliente/detalhes/" + $scope.sp.id) {
        if ($scope.sp.id) {

            $scope.tituloPagina = "Atualizando cliente";
            $scope.typeButton = "Atualizar";
            $scope.idCliente = $scope.sp.id;
            clientesAPIServices.getbyclient($scope.idCliente).then(function (response) {
                $scope.cliente = response.data;
                $scope.cliente.nascimento = moment(response.data.nascimento, "YYYY-MM-DDT00:00:00").format('DD/MM/YYYY');
                $scope.idade();
            });
            $scope.disabledOption = false;
            $scope.readonlyOption = false;
        } else {

            $scope.tituloPagina = "Cadastrando novo cliente";
            $scope.typeButton = "Cadastrar";
            $scope.cliente = {};
            $scope.idade();
            $scope.disabledOption = false;
            $scope.readonlyOption = false;

        }
    } else {

        $scope.tituloPagina = "Detalhes do cliente";
        $scope.typeButton = "Atualizar";
        $scope.idCliente = $scope.sp.id;
        clientesAPIServices.getbyclient($scope.idCliente).then(function (response) {
            $scope.cliente = response.data;
            $scope.cliente.nascimento = moment(response.data.nascimento, "YYYY-MM-DDT00:00:00").format('DD/MM/YYYY');
            $scope.idade();
        });
        $scope.disabledOption = true;
        $scope.readonlyOption = true;
        $('#botaoSave').prop("disabled", true);	

    }


    $scope.toastNotify = function () {
        var x = document.getElementById("snackbar");
        x.className = "show";
        setTimeout(() => {
            x.className = x.className.replace("show", "");
            $state.go('/clientes');
        }, 2000);
    };

    $scope.createCliente = function () {
        

        $scope.cpf = $('.cpf').val();
        $scope.cliente.cpf = $scope.cpf.replace('.', '').replace('.', '').replace('.', '').replace('-', '');

        if ($scope.cliente.cpf === undefined || $scope.cliente.cpf.length < 11 ) {
            $scope.cpfObrigatorio = 'ERRO! CPF OBRIGATÓRIO';
        } else {
            $scope.cpfObrigatorio = '';
        }
        if ($scope.cliente.nome === undefined) {
            $scope.nomeObrigatorio = 'ERRO! NOME OBRIGATÓRIO';
        } else {
            $scope.nomeObrigatorio = '';
        }
        if ($scope.cliente.sobrenome === undefined) {
            $scope.sobrenomeObrigatorio = 'ERRO! SOBRENOME OBRIGATÓRIO';
        } else {
            $scope.sobrenomeObrigatorio = '';
        }
        if ($scope.cliente.nascimento === undefined) {
            $scope.nascimentoObrigatorio = 'ERRO! DATA DE NASCIMENTO OBRIGATÓRIO';
        } else {
            $scope.nascimentoObrigatorio = '';
        }

        if ($scope.sp.id) {

            $scope.cliente.nascimento = moment($scope.cliente.nascimento, "DD/MM/YYYY").format("YYYY-MM-DDT00:00:00");

            clientesAPIServices.atualizarCliente($scope.cliente).then(function (params) {

                $scope.toastNotify();

            });

        } else {


            $scope.cliente.nascimento = moment($scope.cliente.nascimento, "DD/MM/YYYY").format("YYYY-MM-DDT00:00:00");

            clientesAPIServices.createCliente($scope.cliente).then(function (params) {

                $scope.toastNotify();

            });

        }
    }

});