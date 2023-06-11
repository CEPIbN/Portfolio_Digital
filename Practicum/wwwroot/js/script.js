getData();
const infoForm = document.getElementById("infoForm");

infoForm.addEventListener("submit", function (event) {
    event.preventDefault();

    const name = document.getElementById("name").value;
    const lastName = document.getElementById("lastName").value;
    const phoneNumber = document.getElementById("phoneNumber").value;
    const age = document.getElementById("age").value;

    const formData = {
        name: name,
        lastName: lastName,
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
            getData();
            console.log("Данные успешно отправлены!", data);
        })
        .catch(error => {
            // Обработка ошибки
            console.error("Произошла ошибка при отправке данных:", error);
        });
});

async function getData() {
    const response = await fetch("/api/UserApi/GetData", {
        method: "GET"
    });

    if (response.ok) {
        const user = await response.json();
        document.getElementById("name").value = user.Name;
        document.getElementById("lastName").value = user.LastName;
        document.getElementById("phoneNumber").value = user.PhoneNumber;
        document.getElementById("age").value = user.Age;
    } else {
        const error = await response.json();
        console.error("Произошла ошибка при получении данных:", error);
    }
}
