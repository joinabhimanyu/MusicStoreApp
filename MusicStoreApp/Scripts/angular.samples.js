
var ngTwitter = angular.module("ngTwitter", []);

ngTwitter.factory("TwitterService", function ($http) {

    return {

        timeline: function () {
            return $http.get("/Social/GetData")
        }
    }
});

ngTwitter.controller("TimelineController", function ($scope, TwitterService) {

    var resultPromise = TwitterService.timeline();
    resultPromise.success(function (data) {
        $scope.tweets = data;
    });

});

var ngFacebook = angular.module("ngFacebook", []);

ngFacebook.factory("MusicService", function ($http) {

    return {   
        timeline: function () {
            return $http.get("/Social/GetData")
        }
    }
});

ngFacebook.controller("MusicController", function ($scope, MusicService) {

    var resultPromise = MusicService.timeline();
    resultPromise.success(function (data) {
        $scope.musics = data;
    });
});
