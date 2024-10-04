$(document).ready(function () {
    $('#classification').on('change', function () {
        var classificationId = $(this).val();
  

        var SubList = $('#sub');

        SubList.empty();
        //MdaList.append('<option></option>');

        if (classificationId !== '') {
            $.ajax({
                url: '/Home/GetSubs?classificationId=' + classificationId,
                success: function (Subs) {
                    console.log(Subs);
                    $.each(Subs, function (i, sub) {
                        console.log(sub.subClaId);
                        console.log("line--------------------------");
                        console.log(sub.SubClaId);
                        $('#sub').append($('<option></option>').attr('value', sub.subClaId).text(sub.name));
                    });
                },
                error: function () {
                    alert('حدث خطأ ما');
                }
            });
        };
    });

});