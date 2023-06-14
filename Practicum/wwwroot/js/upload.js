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
    } else {
        notification.textContent = 'Не удалось загрузить файл';
    }
});
