/*async function getData() {
    try {
        const response = await fetch('api/UserApi/GetData');
        if (response.ok) {
            const user = await response.json();
            document.getElementById('name').value = user.name;
            document.getElementById('lastName').value = user.lastName;
            document.getElementById('phoneNumber').value = user.phoneNumber;
            document.getElementById('age').value = user.age;
        } else {
            const error = await response.json();
            console.error('Ошибка получения данных:', error.message);
        }
    } catch (error) {
        console.error('Ошибка получения данных:', error);
    }
}*/


async function updateData() {
    const name = document.getElementById('name').value;
    const lastName = document.getElementById('lastName').value;
    const phoneNumber = document.getElementById('phoneNumber').value;
    const age = document.getElementById('age').value;

    const userData = {
        name,
        lastName,
        phoneNumber,
        age
    };

    try {
        const response = await fetch('api/UserApi/Update', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userData)
        });

        if (response.ok) {
            const user = await response.json();
            document.getElementById('name').value = user.name;
            document.getElementById('lastName').value = user.lastName;
            document.getElementById('phoneNumber').value = user.phoneNumber;
            document.getElementById('age').value = user.age;
        } else {
            const error = await response.json();
            console.error('Ошибка обновления данных:', error.message);
        }
    } catch (error) {
        console.error('Ошибка обновления данных:', error);
    }
}
//getData();
const el = document.getElementById('saveBtn');
if (el) {
    el.addEventListener("submit", (event) => {
        event.preventDefault(); 
        updateData(); 
    });
}

