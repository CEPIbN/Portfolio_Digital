//const searchInput = document.getElementById('searchInput').value;
//const url = `/api/UserApi/GetProjectsWithQuery?searchInput=${searchInput}`;
getData();
async function getData() {
    fetch("/api/UserApi/GetProjectsWithQuery")
        .then(response => response.json())
        .then(data => {
            var projects = data;
            var projectsList = document.getElementById('projects-list');

            projects.forEach(project => {
                var fileName = project.fileName;
                var viewName = project.viewName;
                var description = project.description;
                var fileData = project.data;
                var contentType = project.contentType;
                var user = project.user;
                var linkContact = user.phoneNumber;

                var listItem = document.createElement('li');
                var fileNameElement = document.createElement('h3');
                fileNameElement.textContent = viewName;
                var descriptionElement = document.createElement('p');
                descriptionElement.textContent = description;
                var downloadLink = document.createElement('a');
                downloadLink.textContent = 'Скачать';
                downloadLink.href = 'data:application/octet-stream;base64,' + btoa(fileData);
                downloadLink.download = fileName;
                var linkElement = document.createElement('a');
                linkElement.href = linkContact;
                linkElement.textContent = 'Связь';
                var imageElement = document.createElement("img");
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
                } else {
                    imageElement.src = "../../images/normal.png";
                }

                listItem.appendChild(imageElement);
                listItem.appendChild(fileNameElement);
                listItem.appendChild(descriptionElement);
                listItem.appendChild(downloadLink);
                listItem.appendChild(linkElement);
                projectsList.appendChild(listItem);

            });
        })
        .catch(error => {
            console.error('Ошибка при получении списка проектов:', error);
        });
};
