function PostTodo() {
    event.preventDefault();
    var url = '/Todo/Add';
    var formData = new FormData();
    formData.append("Text", $("#text").val());
    var res = $("#text").val();
    $.ajax({
        type: 'Post',
        url: url,
        contentType:false,
        processData: false,
        cache: false,
        data: formData,
        success: function (response) {
            if (response.message != null) {
                $('#errorMessages').html('<p>' + response.message + '</p>');
            }   
            location.reload();
        }, error: function (xhr) {
            var errors = xhr.responseJSON;
            var errorList = '<ul>';
            $.each(errors, function (index, error) {
                errorList += '<li>' + error + '</li>';
            });
            errorList += '</ul>';
            $('#errorMessages').html(errorList);
        }

    });
};

function deleteToDo(Id) {
    var url = '/Todo/DeleteToDo';
    var formData = new FormData();
    formData.append("Id", Id);
    $.ajax({
        type: 'POst',
        url: url,
        contentType: false,
        processData: false,
        cache: false,
        data: formData,
        success: function (response) {
            location.reload();
        }
    });
};

function ChengStatus(Id, Done) {
    var url = '/Todo/ComplateToDo';
    var formData = new FormData();
    formData.append("Done", Done);
    formData.append("Id", Id);
    $.ajax({
        type: 'POst',
        url: url,
        contentType: false,
        processData: false,
        cache: false,
        data: formData,
        success: function (response) {
            location.reload();
        }
    });
}