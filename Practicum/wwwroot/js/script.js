const infoForm = document.getElementById("infoForm");
const notification = document.getElementById("notification");

infoForm.addEventListener("submit", function (event) {
    event.preventDefault();

    const name = document.getElementById("name").value;
    const lastName = document.getElementById("lastName").value;
    const phoneNumber = document.getElementById("phoneNumber").value;

    const formData = {
        Name: name,
        LastName: lastName,
        PhoneNumber: phoneNumber,
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
            notification.textContent = "Данные успешно сохранены!";
            notification.classList.remove("error");
            notification.classList.add("success");
            console.log("Данные успешно отправлены!", data);
        })
        .catch(error => {
            notification.textContent = "Произошла ошибка при отправке данных";
            notification.classList.remove("success");
            notification.classList.add("error");
            console.error("Произошла ошибка при отправке данных:", error);
        });
});

getData();
async function getData() {
    fetch("/api/UserApi/GetInfoData")
        .then(response => response.json())
        .then(data => {
            document.getElementById("name").value = data.name;
            document.getElementById("lastName").value = data.lastName;
            document.getElementById("phoneNumber").value = data.phoneNumber;
        })
        .catch(error => {
            console.error("Ошибка при получении данных:", error);
        });
}
