<script>
    document.getElementById('uploadForm').addEventListener('submit', function(e) {
        e.preventDefault();

    var form = document.getElementById('uploadForm');
    var formData = new FormData(form);

    fetch('api/UserApi/UploadFile', {
        method: 'POST',
    body: formData
            })
    .then(function(response) {
                if (response.ok) {
        alert('File uploaded successfully!');
    form.reset();
                } else {
        alert('File upload failed!');
                }
            })
    .catch(function(error) {
        console.error('Error:', error);
            });
        });
</script>