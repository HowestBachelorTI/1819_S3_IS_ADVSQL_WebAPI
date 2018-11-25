
(function () {
    const apiURL = 'api/student';

    window.addEventListener('load', function () {     
        let studentDetail = document.getElementById('studenten');
        fetch(`${apiURL}`)
            .then(res => res.json())
            .then(function (studenten) {
                studenten.forEach(function (student, i) {
                    let listItem = document.createElement('li');
                    listItem.innerHTML = formatStudent(student);
                    studentDetail.appendChild(listItem);
                });
            })
            .catch(err => console.error('Fout: ' + err));

        document.getElementById('btnSearchById').addEventListener("click", function () {
            var id = document.getElementById('studentId').value;
            let studentDetail = document.getElementById('student');
            fetch(`${apiURL}/${id}`)
                .then(res => res.json())
                .then(function (student) {
                        studentDetail.innerHTML = formatStudent(student);    
                })
                .catch(function (err) {
                    studentDetail.innerHTML = 'Student niet gevonden';
                });
        });
    });

    function formatStudent(student) {
        return `${student.familienaam} ${student.voornaam} (${student.studentnr}): ${student.aantalInschrijvingen}`;
    }


}());



