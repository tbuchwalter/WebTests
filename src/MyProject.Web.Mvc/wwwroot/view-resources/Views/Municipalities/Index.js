var municipalitiesTable;
$(function() {
    DataTableHandler.handleDataTableDefaults();
   
    
    municipalitiesTable = $("#MunicipalitiesTable").DataTable({
        "serverSide": true,
        "language": {
            emptyTable: "No Content to Display",
            search: "_INPUT_",
            searchPlaceholder: "Search"
        },
        "ajax": {
            "type": "POST",
            "url": abp.appPath + 'Municipalities/MunicipalitiesTable',
            "contentType": 'application/json; charset=utf-8',
            "data": function(data) {
                var model = {
                    param: data,
                    activeFilter: $('#activeFilter').val()
                }

                return data = JSON.stringify(model);
            }
        },
        "dom": "<'dt-head clearfix'lrf>t",
        "scrollY": 600, //DataTableHandler.generateDtHeight(),
        "columns": [
            { "data": "name", "orderable": true },
            { "data": "email", "orderable": true },
            { "data": "pointOfContact", "orderable": true },
            { "data": "isActive", "orderable": true },
            {
                "orderable": false,
                className: 'dropdown',
                render: function() {
                    return '  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><i class="material-icons">menu</i></a><ul class="dropdown-menu pull-right"><li><a href="#" class="waves-effect waves-block edit-type" data-toggle="modal" data-target="#MunicipalitiesEditModal"><i class="material-icons">edit</i>Edit</a></li><li><a href="#" class="waves-effect waves-block delete-type" ><i class="material-icons">delete_sweep</i>Delete</a></li></ul>';

                }
            }
        ],
        "order": [1, "asc"]
    });

    DataTableHandler.currentTable.setTable($("#MunicipalitiesTable"));

    $("#MunicipalitiesTable").on('click',
        '.edit-type',
        function(e) {
            e.preventDefault();
            var rowData = municipalitiesTable.row($(this).closest('tr')).data();


            e.preventDefault();
            $.ajax({
               
                url: abp.appPath + 'Municipalities/EditMunicipalities?municipalitiesId=' + rowData.id,
                type: 'Get',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: function(content) {
                    $('#MunicipalitiesEditModal div.modal-content').html(content);
                },
                error: function () {
                    abp.message.error("Edit was not Successful. \n Please try again or contact administration", "ERROR MESSAGE");

                }

            });


        });

    $('#MunicipalitiesTable').on('click',
        '.delete-type',
        function(e) {
            e.preventDefault();
            var rowData = municipalitiesTable.row($(this).closest('tr')).data();

            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AllPoints'), rowData.name),
                function(isConfirmed) {
                    if (isConfirmed) {

                        $.ajax({
                            url: abp.appPath + 'Municipalities/DeleteMunicipalities',
                            type: 'POST',
                            data: { municipalitiesId: rowData.id},
                            success: function (content) {

                                if (content.result.reload) {
                                    
                                    $('#MunicipalitiesEditModal div.modal-content').html(content);
                                    toastr.success("Municipality Item Deleted", rowData.name + " Deleted");
                                    municipalitiesTable.ajax.reload();
                                } else {
                                    toastr.error("Something went wrong, reload is false", "Reload Return Error");
                                } 

                                
                            },
                            error: function () {
                                abp.message.error("Delete was not successful. \n Please try again or contact administration", "ERROR MESSAGE");

                            }

                        });

                    }
                }
            );


        });
    $("#activeFilter").on('change',
        function() {


            municipalitiesTable.ajax.reload();

        });


    $("#add-new-button").on('click',
        function(e) {

            e.preventDefault();
            console.log("Hit the new button function");
            $.ajax({
                url: abp.appPath + 'Municipalities/EditMunicipalities?municipalitiesId=' + 0,
                type: 'Get',
                contentType: 'application/html',
                success: function(content) {
                    
                    $('#MunicipalitiesEditModal div.modal-content').html(content);
                },
                error: function () {
                    abp.message.error("Adding a new Municipality was not successful. \n Please try again or contact administration", "ERROR MESSAGE");

                }

            });


        });


});
