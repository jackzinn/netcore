app.controller('clientesCtrl', function ($scope, $state, $rootScope, clientesAPIServices) {

    $scope.tituloPagina = "Lista de clientes";
    
    $scope.cpfMask = function (v) {

        v = v.replace(/\D/g, "") //Remove tudo o que não é dígito
        v = v.replace(/(\d{3})(\d)/, "$1.$2") //Coloca um ponto entre o terceiro e o quarto dígitos
        v = v.replace(/(\d{3})(\d)/, "$1.$2") //Coloca um ponto entre o terceiro e o quarto dígitos
        //de novo (para o segundo bloco de números)
        v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2") //Coloca um hífen entre o terceiro e o quarto dígitos
        return v;
    }


    $scope.clientes = [];
    clientesAPIServices.getallcliente().then(function (response) {
        $scope.clientes = response.data;
        angular.forEach($scope.clientes, (value, index) => {
            $scope.clientes[index].cpf = $scope.cpfMask(value.cpf);
            $scope.clientes[index].nascimento = moment(value.nascimento, "YYYY-MM-DDT00:00:00").format('DD/MM/YYYY');

            // verificar tipo profissao
            switch ($scope.clientes[index].profissao) {
                case 1:
                    $scope.clientes[index].profissao = 'Analista';
                    break;
                case 2:
                    $scope.clientes[index].profissao = 'Gerente';
                    break;
                case 3:
                    $scope.clientes[index].profissao = 'QA';
                    break;
                case 4:
                    $scope.clientes[index].profissao = 'Estagiário';
                    break;
                case 5:
                    $scope.clientes[index].profissao = 'Programador';
                default:
                    $scope.clientes[index].profissao = 'Vazio'
                    break;
            };
        });
    });


    $scope.toastNotifyConfirm = function () {
        var x = document.getElementById("snackbar");
        x.className = "show";
        setTimeout(() => {
            x.className = x.className.replace("show", "");

        }, 3000);
    };

    // TOAST CANCELADO
    $scope.toastNotifyCancekl = function () {
        var x = document.getElementById("snackbarCancel");
        x.className = "show";
        setTimeout(() => {
            x.className = x.className.replace("show", "");

        }, 3000);
    };


    $scope.editarCliente = function (event) {
        $state.go('/cliente/editar/:id', {
            id: event.target.value
        });
    };

    $scope.visualizarCliente = function (event) {
        $state.go('/cliente/detalhes/:id', {
            id: event.target.value
        });
    };

    $scope.idClienteSelected = null;

    $scope.excluirCliente = function (event) {
        $scope.idClienteSelected = event.target.value;
        $('#modalClientes').modal('show');
    }

    $('#excluirClienteModal').click(function (selected) {
        clientesAPIServices.deleteCliente($scope.idClienteSelected).then(function (response) {
            $scope.toastNotifyConfirm();
            $('#modalClientes').modal('hide');
            $scope.idClienteSelected = null;
            setTimeout(() => {
                location.reload(true);
            }, 3500);

        });
    });

    $('#cancelarExclusao').click(function (selected) {
        $scope.toastNotifyCancekl();
        $('#modalClientes').modal('hide');
    });
});