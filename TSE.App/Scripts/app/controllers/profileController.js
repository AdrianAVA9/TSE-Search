var ProfileController = function (profileService) {

    var searchProfile = function (profileId,controllerId) {
        profileService.searchProfile(done,fail, profileId, controllerId);
    };

    var done = function (data) {
        var profileInfo = JSON.parse(data);

        if (profileInfo != null) {
            $('#username').val(profileInfo['Name']);
            $('#lastname').val(profileInfo['Lastname']);
            $('#birthdate').val(formatDateTime(profileInfo['Birthdate']));
        } else {
            $('#message-title').text('Resultado de busqueda');
            $('#message-details').text('El número de cédula no se encuentra registrado, por favor intente con otro.');
            $('#modal').modal('show');
        }
    };

    var fail = function (error) {
        console.log(error);
    };

    var formatDateTime = function (datetime) {
        var date = new Date(datetime);
        return `${date.getDate()} ${date.toLocaleString('es-CR', { month: 'long' })} ${date.getFullYear()}`;
    };

    var formatMonth = function (month) {
        if (month > 9) return month;
        return '0' + month;
    };

    return {
        searchProfile: searchProfile
    };

}(ProfileService)