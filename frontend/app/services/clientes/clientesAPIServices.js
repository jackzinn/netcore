app.service('clientesAPIServices', function ($http, $rootScope) {

    let _getallclientes = function(params){
        return $http({
            method: 'GET',
            url: 'https://localhost:5001/cliente'
        });
    };
    let _getbyidclient = function(params){
        return $http({
            method: 'GET',
            url: 'https://localhost:5001/cliente/'+params,

        });
    };
    let _createClient = function(params){
        return $http({
            method: 'POST',
            url: 'https://localhost:5001/cliente',
            data : params
        })
    };
    let _atualizarClient = function(params){
        return $http({
            method: 'PUT',
            url: 'https://localhost:5001/cliente/'+params.idCliente,
            data : {
                idCliente:params.idCliente,
                nome:params.nome,
                sobrenome:params.sobrenome,
                nascimento:params.nascimento,
                idade:params.idade,
                cpf:params.cpf,
                profissao:params.profissao
            }
        })
    };

    let _deleteClient = function(params){
        return $http({
            method: 'DELETE',
            url: 'https://localhost:5001/cliente/'+params,
        })
    };
      
      
    

    return {
        atualizarCliente:_atualizarClient,
        getallcliente : _getallclientes,
        getbyclient: _getbyidclient,
        createCliente: _createClient,
        deleteCliente: _deleteClient
    };
});