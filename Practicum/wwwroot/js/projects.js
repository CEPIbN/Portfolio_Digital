﻿$(document).ready(function () {
    $.get('/api/UserApi/GetProjects', function (data) {
        var projectsList = $('#projects-list');

        for (var i = 0; i < data.length; i++) {
            var project = data[i];
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