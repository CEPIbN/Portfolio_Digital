getData();
async function getData() {
    fetch("/api/UserApi/GetData")
        .then(response => response.json())
        .then(data => {
            var user = data.user;
            var projects = data.projects;
            document.getElementById("name").textContent = user.name;
            document.getElementById("last-name").textContent = user.lastName;
            //document.getElementById("phone-number").textContent = user.phoneNumber;
            document.getElementById("email").textContent = user.email;
            var userInfo = document.getElementById("user-info");
            var linkContact = document.createElement('a');
            linkContact.href = user.phoneNumber;
            linkContact.textContent = 'Связь';
            userInfo.appendChild(linkContact);

            console.log("данные вернулись");

            var projectsList = document.getElementById("projects-list");

            if (projects != null) {
                projects.forEach(project => {
                    var fileName = project.fileName;
                    var viewName = project.viewName;
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
                    var fileNameElement = document.createElement('h3');
                    fileNameElement.textContent = viewName;
                    var descriptionElement = document.createElement('p');
                    descriptionElement.textContent = description;
                    var imageElement = document.createElement("img");
                    imageElement.src = "../../images/normal.png";

                    listItem.appendChild(imageElement);
                    listItem.appendChild(fileNameElement);
                    listItem.appendChild(descriptionElement);
                    listItem.appendChild(link);
                    projectsList.appendChild(listItem);

                    if (contentType.includes("image")) {
                        imageElement.src = "../../images/standart.png";
                    } else if (contentType.includes("pdf") || contentType.includes("doc")) {
                        imageElement.src = "../../images/document.png";
                    } else if (contentType.includes("xls") || contentType.includes("csv")) {
                        imageElement.src = "../../images/excel.png";
                    } else if (contentType.includes("ppt")) {
                        imageElement.src = "../../images/powerpoint.png";
                    } else if (contentType.includes("text")) {
                        imageElement.src = "../../images/text.png";
                    }
                });

                console.log("данные вернулись");
            } else {
                console.log("добавьте проекты, чтобы увидеть в каталоге");
            }
        })
        .catch(error => {
            console.error("Ошибка при получении данных:", error);
        });
};