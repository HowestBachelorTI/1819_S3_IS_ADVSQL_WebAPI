
(function () {
    var apiURL = 'api/cursus';

    window.addEventListener('load', function () {     
        let cursusDetail = document.getElementById('cursussen');
        fetch(`${apiURL}`)
            .then(res => res.json())
            .then(function (cursussen) {
                cursussen.forEach(function (cursus, i) {
                    let listItem = document.createElement('li');
                    listItem.innerHTML = formatCursus(cursus);
                    cursusDetail.appendChild(listItem);
                });
            })
            .catch(err => console.error('Fout: ' + err));

        document.getElementById('btnSearchById').addEventListener("click", function () {
            var id = document.getElementById('cursusId').value;
            let cursusDetail = document.getElementById('cursus');
            fetch(`${apiURL}/${id}`)
                .then(res => res.json())
                .then(function (cursus) {
                        cursusDetail.innerHTML = formatCursus(cursus);    
                })
                .catch(function (err) {
                    cursusDetail.innerHTML = 'Cursus niet gevonden';
                });
        });

        document.getElementById('btnSearchAdvanced').addEventListener("click", function () {
            var naam = document.getElementById('cursusNaam').value;
            var maxInschrijving = document.getElementById('cursusMaxInschrijving').value;
            let cursusDetail = document.getElementById('cursussenAdvanced');
            cursusDetail.innerHTML = '';
            fetch(`${apiURL}/${naam}/${maxInschrijving}`)
                .then(res => res.json())
                .then(function (cursussen) {
                    cursussen.forEach(function (cursus, i) {
                        let listItem = document.createElement('li');
                        listItem.innerHTML = formatCursus(cursus);
                        cursusDetail.appendChild(listItem);
                    });
                })
                .catch(err => console.error('Fout: ' + err));
        });

    });

    function formatCursus(cursus) {
        return `${cursus.cursusnaam} (${cursus.id}): ${cursus.inschrijvingsgeld}`;
    }

}());



