function tableInit() {
    
    $('#table-area').DataTable({
        paging: false,
        searching: false,
        info: false,
        ajax: {
            url: '/task/loadtable',
            dataSrc: function (json) {  $('#sum-time h3').text("Sum time: " + json.sumTime); return json.data; }
        },
        columns: [
            { data: 'Id' },
            { data: 'Ticket' },
            { data: 'TimeFormat' },
            { data: 'Description' },
            { data: 'StartFormat' },
            { data: 'EndFormat' },
            { data: 'ProjectId', createdCell: function (td, cellData, rowData, row, col) { $(td).hide(); } }
        ]
    });


   
}

function loadTable(url, changeDb) {
    if (changeDb) {
        $.ajax({
            type: "post",
            url: url,
            data: $('#product-data-form').serialize(),
            success: function (data) {
                $('#table-area').DataTable().ajax.url('task/loadtable' + getFilterData()).load(null, false);
                $('#table-area').DataTable().draw();
            }
        });
    }
    else {
        $('#table-area').DataTable().ajax.url('task/loadtable' + getFilterData()).load(null, false);
        $('#table-area').DataTable().draw();
    }
    
    
}

function getFilterData() {
    return '?FilterDate=' + $('#datepicker').val() + '&FilterProject=' + $('#project-filter').val();
}


$(document).ready(function (e) {
    $('.input-group-append').hide();

    tableInit();
    
    $('#project-filter').change(function () { loadTable("", false); });

});

$('#clear-data').click(function (e) { $('#datepicker').val(""); loadTable(e);});

$('#formModalCenter').on('show.bs.modal', function (event) {
    var data = $(event.relatedTarget);
    $('#valid-data').text('');
    $('#task-start').attr('style', '');
    $('#task-end').attr('style', '');
    $('#task-name').attr('style', '');
    var modal = $(this);
    if (data.is('button')) {
        modal.find('#task-id').val("");
        modal.find('#task-name').val("");
        modal.find('#task-description').val("");
        modal.find('#task-start').val("");
        modal.find('#task-end').val("");
        modal.find('#delete-task').hide();
        modal.find('#add-new-task').text('Add');
    }
    else {
       
       
        modal.find('#delete-task').show();
        modal.find('#add-new-task').text('Edit');
    }

});

$('#add-new-task').click(function (e) {

    $('#valid-data').show();
    
    if ($("#task-name").val() !== "" ) {
        $('#task-name').attr('style', '');
        if ($('#task-start').val() !== "" && $('#task-end').val() !== "") {
            var st = parseInt($('#task-start').val().replace(':', ''), 10);
            var end = parseInt($('#task-end').val().replace(':', ''), 10);
            if (st <= end) {
                var idData = $('#task-id');
                var url;
                 
                if (idData.val() === "") {
                    url = "/task/addnewtask";
                }
                else {
                    url = "/task/edittask";
                }
                loadTable(url, true);
                $('#formModalCenter').modal('hide');               
            }
            $('#task-start').attr('style', 'border-color:red');
            $('#task-end').attr('style', 'border-color:red');
            $('#valid-data').text('Start can`t be more than End');
        }
        $('#task-start').attr('style', 'border-color:red');
        $('#task-end').attr('style', 'border-color:red');
        $('#valid-data').text('Input Start and End times');
        return;
    }
    $('#task-name').attr('style', 'border-color:red');
    $('#valid-data').text('Input Ticket');
});

$('#delete-task').click(function (e) {
    var url = 'task/deletetask';
    loadTable(url,true);
    $('#formModalCenter').modal('hide');

});

$('#table-area').on('click','tbody tr', function () {
    var data = $('#table-area').DataTable().row(this).data();
    var modal = $('#formModalCenter');

    modal.find('#task-id').val(data.Id);
    modal.find('#task-name').val(data.Ticket);
    modal.find('#task-description').val(data.Description);
    modal.find('#task-start').val(data.StartFormat);
    modal.find('#task-end').val(data.EndFormat);
    modal.find('#task-project option[value =' + data.ProjectId + ']').prop('selected', true);
    modal.modal("show");
});




