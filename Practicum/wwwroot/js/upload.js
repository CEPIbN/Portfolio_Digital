const form = document.getElementById('uploadForm');
const notification = document.getElementById('notification');

form.addEventListener('submit', async (event) => {
    event.preventDefault(); 

    const formData = new FormData(form); 
    const response = await fetch('/api/UserApi/UploadFile', {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        notification.textContent = 'Файл успешно загружен';
        notification.classList.remove("error");
        notification.classList.add("success");
        console.log("Данные успешно отправлены!");
    } else {
        error = response.json();
        notification.textContent = 'Не удалось загрузить файл';
        notification.classList.remove("success");
        notification.classList.add("error");
        console.error("Произошла ошибка при отправке данных:", error);
    }
});
