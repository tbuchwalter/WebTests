(function ($) {
    
    var _$modal = $('#MunicipalitiesEditModal');
    var _$form = $('form[name=MunicipalitiesEditForm]');

 
    _$form.submit(function(e) {
        e.preventDefault();
        
        var municipalities = $(this).serializeFormToObject();
        
        abp.ajax({
            method: this.method,
            url: this.action,
            data: municipalities,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8'
        }).done(function(result) {
            if (result.success === false) {
            } else {
                $('#MunicipalitiesEditModal').modal('hide');
                municipalitiesTable.ajax.reload();
                toastr.success("Municipality Item Saved", municipalities.Name + " Saved");
                   
            }
        });

    });

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        _$form.submit();
        // save();
    });


    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            _$form.submit();
          
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
