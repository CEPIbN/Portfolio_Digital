getData();
async function getData() {
    fetch("/api/UserApi/GetData")
        .then(response => response.json())
        .then(data => {
            var projects = data.projects;
            document.getElementById("name").textContent = data.name;
            document.getElementById("last-name").textContent = data.lastName;
            document.getElementById("phone-number").textContent = data.phoneNumber;
            document.getElementById("email").textContent = data.email;
            console.log("данные вернулись")
            var projectsList = document.getElementById("projects-list");
            if (projects != null) {
                projects.forEach(project => {
                    var fileName = project.fileName;
                    var description = project.description;
                    var fileData = project.data;
                    var contentType = project.contentType;

                    const blob = new Blob([fileData], { type: contentType });
                    const fileUrl = URL.createObjectURL(blob);
                    const link = document.createElement('a');
                    link.href = fileUrl;
                    link.download = fileName; 
                    link.innerText = 'Скачать файл';
                    var listItem = document.createElement('li');
                    var fileNameElement = document.createElement('h3').textComtent = fileName;
                    var descriptionElement = document.createElement('p').textContent = description;
                    listItem.append(fileNameElement, descriptionElement, link);
                    projectsList.append(listItem);
                })
                console.log("данные вернулись")
            }
            else {
                console.log("добавьте проекты, чтобы увидеть в каталоге")
            }
            //console.log("данные вернулись")
        })
        .catch(error => {
            console.error("Ошибка при получении данных:", error);
        });
};