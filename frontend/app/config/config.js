app.run(function($rootScope){
    $rootScope.global = {
        titlePage : '',
    };
});

app.config(function($stateProvider, $urlRouterProvider){
    $urlRouterProvider.otherwise('/clientes');
    
    $stateProvider.state('/clientes', {

        url: '/clientes',
        templateUrl: 'app/views/cliente.html',
        controller: 'clientesCtrl'

    }).state('/cliente/novo', {

        url: '/cliente/novo',
        templateUrl: 'app/views/clientenovo.html',
        controller: 'novoClienteCtrl'

    }).state('/cliente/editar/:id', {

        url: '/cliente/editar/:id',
        templateUrl: 'app/views/clientenovo.html',
        controller: 'novoClienteCtrl'

    }).state('/cliente/detalhes/:id', {

        url: '/cliente/detalhes/:id',
        templateUrl: 'app/views/clientenovo.html',
        controller: 'novoClienteCtrl'

    })
    
});