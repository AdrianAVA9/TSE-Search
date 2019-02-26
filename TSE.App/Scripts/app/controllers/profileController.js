var ProfileController = function (profileService) {

    var searchProfile = function (profileId, controllerId) {
        profileService.searchProfile(done, fail, profileId, controllerId);
    };

    var done = function (data) {
        var profileInfo = JSON.parse(data);

        if (profileInfo !== null) {
            $('#username').val(profileInfo['Name']);
            $('#lastname').val(profileInfo['Lastname']);
            $('#birthdate').val(profileInfo['DateOfBirthFormat']);
        } else {
            $('#message-title').text('Resultado de busqueda');
            $('#message-details').text('El número de cédula no se encuentra registrado, por favor intente con otro.');
            $('#modal').modal('show');
        }
    };

    var fail = function (error) {
        console.log(error);
        $('#message-title').text('Error');
        $('#message-details').text('Upss! algo salio mal, por favor intente mas tarde');
        $('#modal').modal('show');
    };

    return {
        searchProfile: searchProfile
    };

}(ProfileService);