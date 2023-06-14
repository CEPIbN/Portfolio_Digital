$(document).ready(function() {
    $.get('/api/UserApi/GetData', function(data) {
        var user = data.User;
        $('#name').text(user.Name);
        $('#last-name').text(user.LastName);
        $('#phone-number').text(user.PhoneNumber);
        $('#age').text(user.Age);
        $('#email').text(user.Email);

        var projects = data.FileData;
        var projectsList = $('#projects-list');

        for (var i = 0; i < projects.length; i++) {
            var project = projects[i];
            var fileName = project.fileName;
            var description = project.Description;

            var listItem = $('<li>');
            var fileNameElement = $('<h3>').text(fileName);
            var descriptionElement = $('<p>').text(description);

            listItem.append(fileNameElement, descriptionElement);
            projectsList.append(listItem);
        }
    });
});