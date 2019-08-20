$(function () {
    if (typeof loadIdCard == "undefined" || typeof loadIdCard == undefined) {

        
        $('#responsive').modal({ remote: '/client/preview1.aspx?id=' + memberId, show: false });

    }
    $('.row-fluid.send-message textarea').tooltip({ trigger: 'manual' });
});

$('body').delegate('.close', 'click', function () {
    $(this).parents('.success-message,.message-success').slideUp();

    $('.send-message').slideDown(function () {
        $('.modal-body').animate({
            scrollTop: $('.row-fluid.send-message .send').offset().top
        }, 2000);
    });
});
$('body').delegate('.row-fluid.send-message .send', 'click', function (ev) {
    $('.row-fluid.send-message textarea').tooltip('hide');
    ev.preventDefault();
    var message = $('.row-fluid.send-message textarea').val();
    var memberId = $(this).data('id');
    if (message == '') {
        $('.row-fluid.send-message textarea').tooltip('show');
        return;
    }

    $.ajax({
        url: "/handlers/SendMessage.ashx",
        type: 'post',
        dataType: 'json',
        data: {
            id: memberId,
            message: message
        },
        success: function (data) {
            if (data.success == false) {
                $('.success-alert').addClass('alert-error');
            }
            var message = data.message;
            $('.row-fluid.send-message textarea').val('');
            $('.success-alert span').text(message);
            $('.send-message').slideUp(function () {
                $('.message-success').insertBefore($('.send-message')).slideDown();
            });
        }
    });
});

$('#responsive').on('shown', function () {
    $('.row-fluid.send-message textarea').tooltip({ trigger: 'manual' });
});
$('body').delegate('.row-fluid.send-message textarea', 'focus', function () {
    $(this).tooltip('hide');
});