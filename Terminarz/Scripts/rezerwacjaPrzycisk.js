const openModal = document.getElementById('openModal');
const cancel = document.getElementById('cancel');
const modal = document.getElementById('modal');

openModal.addEventListener('click', (e) => {
    e.preventDefault();
    modal.style.display = "flex";
    e.target.disabled = true;
});

cancel.addEventListener('click', (e) => {
    openModal.disabled = false;
    modal.style.display = "none";
    $('.second_part').css('display', 'none');
});

const confirm_hour = (hour) => {

    return `Czy na pewno chcesz się umówić na ${hour}?
    <button id="confirm_hour">Umów na wybraną godzinę</button>`;
};

$('.hour').on('click', (e) => {
    $('.confirm_hour_body').html(confirm_hour(e.target.textContent));
    const chosenButton = e.target
    $('#confirm_hour').on('click', () => {
        chosenButton.style.backgroundColor = 'green';
        chosenButton.disabled = true;
        $('.confirm_hour_body').hide();
        $('.second_part').css('display', 'flex');
    });
});

const signUp = document.getElementById('confirm');
const name = document.getElementById('name');
const surname = document.getElementById('surname');
signUp.addEventListener('click', (e) => {
    e.preventDefault();
    if (name.value !== '' && surname.value !== '') {
        if (name.value === 'Damian' && surname.value === 'Zmarzły') {
            const damian = document.getElementById('damian');
            damian.innerHTML = "Ty nie możesz xd"
        }
        modal.style.display = "none";
        openModal.textContent = "Brak wolnego terminu";
        alert("Zapisano na wizytę");
    }
    else {
        alert("Puste pole imię lub nazwisko!");
    }
})