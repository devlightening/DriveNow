// wwwroot/Admin/vertical/assets/js/CarListScripts.js

document.addEventListener('DOMContentLoaded', function () {
    // Arama ve Filtreleme İşlevleri
    const searchInput = document.getElementById('carSearchInput');
    const carItemWrappers = document.querySelectorAll('.car-item-wrapper');

    if (searchInput && carItemWrappers.length > 0) {
        searchInput.addEventListener('keyup', filterCars);
        searchInput.addEventListener('input', function () {
            if (searchInput.value.trim() === '') {
                carItemWrappers.forEach(itemWrapper => {
                    itemWrapper.classList.remove('d-none');
                });
            }
        });
    }

    function filterCars() {
        const searchTerm = searchInput.value.toLowerCase().trim();
        carItemWrappers.forEach(itemWrapper => {
            const brandData = itemWrapper.dataset.brand ? itemWrapper.dataset.brand.toLowerCase() : '';
            const modelData = itemWrapper.dataset.model ? itemWrapper.dataset.model.toLowerCase() : '';
            const yearData = itemWrapper.dataset.year ? itemWrapper.dataset.year.toLowerCase() : '';
            const typeData = itemWrapper.dataset.type ? itemWrapper.dataset.type.toLowerCase() : '';
            const fuelTypeData = itemWrapper.dataset.fueltype ? itemWrapper.dataset.fueltype.toLowerCase() : '';
            const transmissionData = itemWrapper.dataset.transmission ? itemWrapper.dataset.transmission.toLowerCase() : '';

            const matchesSearchTerm =
                brandData.includes(searchTerm) ||
                modelData.includes(searchTerm) ||
                yearData.includes(searchTerm) ||
                typeData.includes(searchTerm) ||
                fuelTypeData.includes(searchTerm) ||
                transmissionData.includes(searchTerm);

            if (matchesSearchTerm) {
                itemWrapper.classList.remove('d-none');
            } else {
                itemWrapper.classList.add('d-none');
            }
        });
    }

    // Sayfa yüklendiğinde kartların başlangıçtaki durumlarını ayarla
    carItemWrappers.forEach(itemWrapper => {
        const isPublished = itemWrapper.getAttribute('data-published') === 'true';
        const card = itemWrapper.querySelector('.car-card');
        const availabilityButton = card.querySelector('.btn-availability-overlay');

        if (isPublished) {
            card.classList.add('published');
            card.classList.remove('unpublished');
            availabilityButton.classList.add('btn-available');
            availabilityButton.classList.remove('btn-unavailable');
            availabilityButton.textContent = 'Available';
        } else {
            card.classList.add('unpublished');
            card.classList.remove('published');
            availabilityButton.classList.add('btn-unavailable');
            availabilityButton.classList.remove('btn-available');
            availabilityButton.textContent = 'Unavailable';
        }
    });
});

// `confirmDelete` ve `toggleAvailability` fonksiyonları global scope'ta olmalıdır
// çünkü HTML içindeki onclick attribute'leri tarafından çağrılıyorlar.

function confirmDelete(button) {
    var carName = $(button).data('car-name');
    var carId = $(button).data('car-id');

    if (confirm("'" + carName + "' Are you sure you want to delete the car?")) {
        window.location.href = "/AdminCar/DeleteCar/" + carId;
    }
}

function toggleAvailability(carId, isCurrentlyPublished) {
    var newStatus = !isCurrentlyPublished;
    var url = "https://localhost:7031/api/Cars/UpdatePublicationStatus";

    // Butonu bul ve geçici olarak 'clicked' sınıfını ekle
    const clickedButton = document.querySelector(`.car-item-wrapper[data-car-id="${carId}"] .btn-availability-overlay`);
    if (clickedButton) {
        clickedButton.classList.add('clicked');
    }

    fetch(url, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ carId: carId, isPublished: newStatus }),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                updateButtonState(carId, newStatus); // Butonun kalıcı durumunu güncelle
                console.log(data.message);
            } else {
                alert(data.message || "Failed to update car status.");
            }
        })
        .catch(error => {
            console.error('Fetch operation error:', error);
            alert("An error occurred while updating availability.");
        })
        .finally(() => {
            // İstek tamamlandığında (başarılı veya hatalı), 'clicked' sınıfını kaldır
            if (clickedButton) {
                clickedButton.classList.remove('clicked');
            }
        });
}
function updateButtonState(carId, newStatus) {
    const itemWrapper = document.querySelector(`.car-item-wrapper[data-car-id="${carId}"]`);
    if (!itemWrapper) return;

    const card = itemWrapper.querySelector('.car-card');
    const availabilityButton = card.querySelector('.btn-availability-overlay');

    if (newStatus) { // Eğer "Available" olacaksa
        card.classList.add('published');
        card.classList.remove('unpublished');
        availabilityButton.classList.add('btn-available'); // Bu sınıfın CSS'te tanımlı olduğundan emin olun
        availabilityButton.classList.remove('btn-unavailable');
        availabilityButton.textContent = 'Available';
    } else { // Eğer "Unavailable" olacaksa
        card.classList.add('unpublished');
        card.classList.remove('published');
        availabilityButton.classList.add('btn-unavailable'); // Bu sınıfın CSS'te tanımlı olduğundan emin olun
        availabilityButton.classList.remove('btn-available');
        availabilityButton.textContent = 'Unavailable';
    }

    itemWrapper.setAttribute('data-published', newStatus.toString().toLowerCase());
}