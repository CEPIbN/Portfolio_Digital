document.getElementById('uploadForm').addEventListener('submit', function (e) {
    e.preventDefault();

    var form = document.getElementById("uploadForm");
    var formData = new FormData(form);

    fetch('api/UserApi/UploadFile', {
        method: "POST",
        body: formData
    })
        .then(function (response) {
            if (response.ok) {
                alert('Файл успешно загружен');
                form.reset();
            }
            else {
                alert('Не удалось загрузить файл!');
            }
        })
        .catch(function (error) {
            console.error('Ошибка:', error);
        });
});