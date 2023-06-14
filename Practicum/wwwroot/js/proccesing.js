
// Обработка данных и отображение проектов
response.forEach(function (project) {
    var projectCard = document.createElement('div');
    projectCard.classList.add('project_cards');

    var projectImage = document.createElement('img');
    projectImage.src = project.imageUrl;
    projectCard.appendChild(projectImage);

    var addProjectContainer = document.createElement('div');
    addProjectContainer.classList.add('add_project_container');
    projectCard.appendChild(addProjectContainer);

    if (project.isExisted) {
        var addButton = document.createElement('button');
        addButton.classList.add('add_project');
        addButton.textContent = 'Add project';
        addProjectContainer.appendChild(addButton);
    } else {
        var projectLink = document.createElement('a');
        projectLink.classList.add('add_project');   
        projectLink.href = '/';
        addProjectContainer.appendChild(projectLink);
    }

    var projectName = document.createElement('p');
    projectName.classList.add('project_name');
    projectName.textContent = project.name;
    projectCard.appendChild(projectName);

    var projectsContainer; // Определяем контейнер, в который будет добавлен проект в зависимости от его статуса (существующий или добавляемый)
    if (project.isExisted) {
        projectsContainer = document.querySelector('.existed');
    } else {
        projectsContainer = document.querySelector('.not-existed');
    }

    projectsContainer.appendChild(projectCard); // Добавляем проект в соответствующий контейнер на странице
});
