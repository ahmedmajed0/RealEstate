$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);


        bootbox.confirm({
            message: "هل انت متأكد من اتمام الحذف",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                console.log(btn.data('id'));
                if (result) {
                    $.ajax({
                        url: '/Admin/Residential/Delete/?id=' + btn.data('id'),
                        method: 'DELETE',
                        success: function () {
                            btn.parents('tr').fadeOut();
                            $('#alert').removeClass('d-none');

                            setTimeout(function () { $('#alert').addClass('d-none'); }, 5000)
                        },
                        error: function () {

                            alert('حدث حطأ ما');
                        }
                    })
                }
            }
        });
    });

    $('.js-delete2').on('click', function () {
        var btn = $(this);


        bootbox.confirm({
            message: "هل انت متأكد من اتمام الحذف",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                console.log(btn.data('id'));
                if (result) {
                    $.ajax({
                        url: '/Admin/Agricultural/Delete/?id=' + btn.data('id'),
                        method: 'DELETE',
                        success: function () {
                            btn.parents('tr').fadeOut();
                            $('#alert').removeClass('d-none');

                            setTimeout(function () { $('#alert').addClass('d-none'); }, 5000)
                        },
                        error: function () {

                            alert('حدث حطأ ما');
                        }
                    })
                }
            }
        });
    })




    $('.js-delete3').on('click', function () {
        var btn = $(this);


        bootbox.confirm({
            message: "هل انت متأكد من اتمام الحذف",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                console.log(btn.data('id'));
                if (result) {
                    $.ajax({
                        url: '/Admin/Commercial/Delete/?id=' + btn.data('id'),
                        method: 'DELETE',
                        success: function () {
                            btn.parents('tr').fadeOut();
                            $('#alert').removeClass('d-none');

                            setTimeout(function () { $('#alert').addClass('d-none'); }, 5000)
                        },
                        error: function () {

                            alert('حدث حطأ ما');
                        }
                    })
                }
            }
        });
    })


    $('.js-delete4').on('click', function () {
        var btn = $(this);


        bootbox.confirm({
            message: "هل انت متأكد من اتمام الحذف",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                console.log(btn.data('id'));
                if (result) {
                    $.ajax({
                        url: '/Admin/Industrial/Delete/?id=' + btn.data('id'),
                        method: 'DELETE',
                        success: function () {
                            btn.parents('tr').fadeOut();
                            $('#alert').removeClass('d-none');

                            setTimeout(function () { $('#alert').addClass('d-none'); }, 5000)
                        },
                        error: function () {

                            alert('حدث حطأ ما');
                        }
                    })
                }
            }
        });
    })


    $('.js-delete5').on('click', function () {
        var btn = $(this);


        bootbox.confirm({
            message: "هل انت متأكد من اتمام الحذف",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                console.log(btn.data('id'));
                if (result) {
                    $.ajax({
                        url: '/Admin/Team/Delete/?id=' + btn.data('id'),
                        method: 'DELETE',
                        success: function () {
                            btn.parents('tr').fadeOut();
                            $('#alert').removeClass('d-none');

                            setTimeout(function () { $('#alert').addClass('d-none'); }, 5000)
                        },
                        error: function () {

                            alert('حدث حطأ ما');
                        }
                    })
                }
            }
        });
    })
})