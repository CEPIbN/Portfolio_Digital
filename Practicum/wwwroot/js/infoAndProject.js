getData();
async function getData() {
    fetch("/api/UserApi/GetData")
        .then(response => response.json())
        .then(data => {
            document.getElementById("name").value = data.Name;
            document.getElementById("last-name").value = data.LastName;
            document.getElementById("phone-number").value = data.PhoneNumber;
            document.getElementById("age").value = data.Age;
            document.getElementById("email").value = data.Email;

            var projects = data.Projects;
            var projectsList = document.getElementById("projects-list");

            projects.forEach(project => {
                var fileName = project.FileName;
                var description = project.Description;
                var fileData = project.Data;

                const fileUrl = URL.createObjectURL(new Blob([fileData]));
                const link = document.createElement('a');
                link.href = fileUrl;
                link.download = fileName; // Укажите имя файла
                link.innerText = 'Скачать файл';
                var listItem = document.createElement('<li>');
                var fileNameElement = document.createElement('<h3>').text(fileName);
                var descriptionElement = document.createElement('<p>').text(description);
                listItem.append(fileNameElement, descriptionElement, link);
                projectsList.append(listItem);
            })
            console.log("данные вернулись")
                
        })
        .catch(error => {
            console.error("Ошибка при получении данных:", error);
        });
};