const form = document.getElementById('uploadForm');
form.addEventListener('submit', async (event) => {
    event.preventDefault(); 

    const formData = new FormData(form); 
    const response = await fetch('/api/UserApi/UploadFile/', {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        console.log('Файл успешно загружен');
    } else {
        console.error('Ошибка при загрузке файла');
    }
});
