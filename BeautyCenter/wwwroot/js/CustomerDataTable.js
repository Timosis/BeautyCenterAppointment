var DatatablesDataSourceAjaxServer = function () {

    var initTable1 = function () {
        var table = $('#m_table_1');

        // begin first table
        table.DataTable({
            responsive: true,
            searchDelay: 500,
            processing: true,
            serverSide: true,
            ajax: '/Customer/Customers_Read/',
            dataSrc: "",
            columns: [
                { data: 'Id' },
                { data: 'RegisteredDate' },
                { data: 'Firstname' },
                { data: 'Lastname' },
                { data: 'Email' },
                { data: 'Telephone' },
            ],
            language: {
                "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Turkish.json"
            }
        });
    };

    return {
        //main function to initiate the module
        init: function () {
            initTable1();
        },
    };
}();

jQuery(document).ready(function () {
    DatatablesDataSourceAjaxServer.init();
});