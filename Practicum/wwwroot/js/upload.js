document.getElementById('uploadForm').addEventListener('submit', function () {
    //e.preventDefault();
    //var form = document.getElementById("uploadForm");
    const fileName = document.getElementById("fileName").value;
    const description = document.getElementById("description").value;
    const file = document.getElementById("file").value;
    
    const fileData = {
        fileName: fileName,
        description: description,
        file: file,
    };
    var formData = new FormData(fileData);
    fetch("/api/UserApi/UploadFile", {
        method: "POST",
        body: formData
    })
        .then(function (response) {
            if (response.ok) {
                alert('Файл успешно загружен');
                form.reset();
            }
            else {
                const error = response.json();
                console.log("Ошибка:", error);
                alert('Не удалось загрузить файл!');
            }
        })
        .catch(function (error) {
            console.error('Ошибка:', error);
        });
});