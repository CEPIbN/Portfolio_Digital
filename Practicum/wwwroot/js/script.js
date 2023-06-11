document.addEventListener("DOMContentLoaded", function () {
    const saveBtn = document.getElementById("saveBtn");

    saveBtn.addEventListener("click", function () {
        const firstName = document.getElementById("firstName").value;
        const middleName = document.getElementById("middleName").value;
        const phoneNumber = document.getElementById("phoneNumber").value;
        const age = document.getElementById("age").value;

        const formData = {
            firstName: firstName,
            middleName: middleName,
            phoneNumber: phoneNumber,
            age: age
        };

        const requestOptions = {
            method: "POST",
            body: JSON.stringify(formData),
            headers: {
                "Content-Type": "application/json"
            }
        };

            fetch("/api/UserApi/Update", requestOptions)
            .then(response => response.json())
            .then(data => {
                // Обработка успешного ответа от сервера
                console.log("Данные успешно отправлены!", data);
            })
            .catch(error => {
                // Обработка ошибки
                console.error("Произошла ошибка при отправке данных:", error);
            });
    });
});
