$(function () {
    var l = abp.localization.getResource('Erp');

    var createModal = new abp.ModalManager(abp.appPath + 'Clientes/CreateModal');

    var editModal = new abp.ModalManager(abp.appPath + 'Clientes/EditModal');

    var dataTable = $('#ClientesTabla').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(inteliventas.erp.clientes.cliente.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ClientDeletionConfirmationMessage',
                                            data.record.nombre
                                        );
                                    },
                                    action: function (data) {
                                        inteliventas.erp.clientes.cliente
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );

                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "nombre"
                },
                {
                    title: l('RUC'),
                    data: "ruc"
                },
                {
                    title: l('DNI'),
                    data: "dni"
                },
                {
                    title: l('Ce'),
                    data: "ce"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NuevoCliente').click(function (e) {
        e.preventDefault();

        createModal.open();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
});