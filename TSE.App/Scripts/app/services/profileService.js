/*
  CALL THE CONTROLLER
    USING LINQ : "/Home/GetProfile_Linq"
    USING SQL_COMMAND : "/Home/GetProfile"
*/

var ProfileService = function () {
    var searchProfile = function (done, fail, id, controllerId) {
        var controllerName = controllerId === 1 ? "GetProfile" : "GetProfile_Linq";

        $.ajax({
            type: 'GET',
            url: '/Home/' + controllerName,
            data: {'id': id },
            contentType: 'json/application'
        }).done(done).fail(fail);
    };

    return {
        searchProfile: searchProfile
    };
}();