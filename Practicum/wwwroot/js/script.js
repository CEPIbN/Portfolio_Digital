async function updateData() {
    var form = document.getElementById("infoForm");
    var formData = new FormData(form);

    fetch("/api/UserApi/Update", {
        method: "POST",
        body: formData
    })
        .then(function (response) {
            if (response.ok) {
                console.log("Данные успешно отправлены");
            } else {
                console.log("Ошибка при отправке данных с сервера");
            }
        })
        .catch(function (error) {
            console.log("Ошибка при выполнении запроса");
            console.log(error);
        });
}
document.getElementById('infoForm').addEventListener('submit', () => updateData());




