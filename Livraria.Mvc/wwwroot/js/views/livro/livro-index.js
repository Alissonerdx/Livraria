"strict"

$(document).ready(function () {
    Tabelas();

    function Tabelas() {
        $('#tabelaLivros').DataTable({
            "select": {
                style: 'single',
                selector: '.selecionavel'
            },
            "language": {
                "url": "/lib/datatablejs/Languages/Portuguese-Brasil.json"
            },
        });
    }

});