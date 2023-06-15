window.addEventListener('DOMContentLoaded', (event) => {
    fetch('/api/UserApi/GetData')
        .then(response => response.json())
        .then(data => {
            var user = data.User;
            document.getElementById('name').textContent = user.Name;
            document.getElementById('last-name').textContent = user.LastName;
            document.getElementById('phone-number').textContent = user.PhoneNumber;
            document.getElementById('age').textContent = user.Age;
            document.getElementById('email').textContent = user.Email;

            var projects = data.FileData;
            var projectsList = document.getElementById('projects-list');

            projects.forEach(project => {
                var fileName = project.fileName;
                var description = project.Description;

                var listItem = document.createElement('li');
                var fileNameElement = document.createElement('h3');
                fileNameElement.textContent = fileName;
                var descriptionElement = document.createElement('p');
                descriptionElement.textContent = description;

                listItem.appendChild(fileNameElement);
                listItem.appendChild(descriptionElement);
                projectsList.appendChild(listItem);
            });
        })
        .catch(error => {
            console.error('Ошибка при получении данных:', error);
        });
});
