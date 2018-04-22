myApp.controller("entityController", function ($scope, $http) {
    $scope.message = "AngularJS Tutorial buddhika";
    $scope.entity = {};
    $scope.entity.participants = [];

    $scope.save = function () {
        $http.post("/api/AppsEntities1", $scope.entity)
            .then(
            function (response) {
                // success callback
            },
            function (response) {
                // failure callback
            }
            );
    };

    $scope.AddParticipant = function () {
        var participant = { participantName: "", type: "" };       
        $scope.entity.participants.push(participant);
    };
});