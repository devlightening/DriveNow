// Bu fonksiyon, araçların "IsPublished" durumunu değiştirmek için bir AJAX çağrısı yapar.
async function toggleAvailability(carId, currentStatus) {
    const button = document.querySelector(`[data-car-id="${carId}"]`);
    const carWrapper = document.querySelector(`[data-car-id="${carId}"]`).closest('.car-item-wrapper');

    // Butonun durumunu "Güncelleniyor..." olarak değiştir ve tıklanmasını engelle
    const originalText = button.textContent;
    button.textContent = 'Updating...';
    button.disabled = true;

    // Yeni durumun ne olacağını belirle
    const newStatus = !currentStatus;

    try {
        // Sunucuya POST isteği gönder
        const response = await fetch(`/AdminCar/ToggleAvailability?id=${carId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ isPublished: newStatus }),
        });

        if (response.ok) {
            // Sunucudan başarılı yanıt gelirse UI'ı güncelle
            const newStatusText = newStatus ? 'Available' : 'Unavailable';
            const newClass = newStatus ? 'btn-available' : 'btn-unavailable';

            // Butonun metnini, sınıfını ve data-attribute'unu güncelle
            button.textContent = newStatusText;
            button.className = `btn btn-availability-overlay ${newClass}`;
            button.setAttribute('data-current-status', newStatus.toString());

            // Ana kartın sınıfını güncelle
            const carCard = carWrapper.querySelector('.car-card');
            if (newStatus) {
                carCard.classList.remove('unpublished');
                carCard.classList.add('published');
            } else {
                carCard.classList.remove('published');
                carCard.classList.add('unpublished');
            }

            // car-item-wrapper'daki data-published özniteliğini güncelle
            carWrapper.setAttribute('data-published', newStatus.toString().toLowerCase());

        } else {
            // Hata durumunda kullanıcıya bilgi ver
            console.error('API isteği başarısız oldu:', response.statusText);
            alert('Durum güncellenirken bir hata oluştu.');
            button.textContent = originalText;
        }
    } catch (error) {
        console.error('API isteği sırasında bir hata oluştu:', error);
        alert('Sunucuya bağlanılamadı. Lütfen tekrar deneyin.');
        button.textContent = originalText;
    } finally {
        // İşlem tamamlandıktan sonra butonu tekrar etkinleştir
        button.disabled = false;
    }
}

// Tarayıcının yerleşik confirm() uyarısı yerine özel bir modal pencere gösterir
function confirmDelete(element) {
    const carId = element.getAttribute('data-car-id');
    const carName = element.getAttribute('data-car-name');

    // Eğer modal daha önce oluşturulmadıysa oluştur
    if (!document.getElementById('confirmationModal')) {
        const modalHtml = `
            <div id="confirmationModal" class="modal-backdrop">
                <div class="modal-content-custom">
                    <p class="modal-message">Are you sure you want to delete ${carName}?</p>
                    <div class="modal-buttons">
                        <button id="modal-cancel-btn" class="btn btn-secondary modal-btn-style">Cancel</button>
                        <button id="modal-confirm-btn" class="btn btn-danger modal-btn-style">Delete</button>
                    </div>
                </div>
            </div>
            <style>
                .modal-backdrop {
                    position: fixed;
                    top: 0;
                    left: 0;
                    width: 100%;
                    height: 100%;
                    background-color: rgba(0, 0, 0, 0.7);
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    z-index: 1050;
                }
                .modal-content-custom {
                    background-color: white;
                    padding: 2rem;
                    border-radius: 1rem;
                    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
                    max-width: 400px;
                    text-align: center;
                    font-family: 'Inter', sans-serif;
                }
                .modal-message {
                    font-size: 1.2rem;
                    color: #333;
                    margin-bottom: 1.5rem;
                }
                .modal-buttons {
                    display: flex;
                    justify-content: space-around;
                }
                .modal-btn-style {
                    font-weight: bold;
                    transition: transform 0.2s ease-in-out;
                    border-radius: 0.5rem;
                }
                .modal-btn-style:hover {
                    transform: translateY(-2px);
                }
            </style>
        `;
        document.body.insertAdjacentHTML('beforeend', modalHtml);
    }

    // Modalı göster
    const modal = document.getElementById('confirmationModal');
    modal.style.display = 'flex';
    document.querySelector('.modal-message').textContent = `Are you sure you want to delete ${carName}?`;

    // Buton eventlerini ayarla
    document.getElementById('modal-confirm-btn').onclick = () => {
        // Silme işlemi için yönlendirme yap
        window.location.href = `/AdminCar/DeleteCar/${carId}`;
        modal.style.display = 'none';
    };

    document.getElementById('modal-cancel-btn').onclick = () => {
        modal.style.display = 'none';
    };
}

// Arama işlemini ve araç sayısını güncelleyen fonksiyon
function updateCarCount() {
    const carItems = document.querySelectorAll('.car-item-wrapper');
    const visibleCars = Array.from(carItems).filter(item => item.style.display !== 'none');
    const carCountSpan = document.getElementById('totalCarCount');
    if (carCountSpan) {
        carCountSpan.textContent = visibleCars.length;
    }
}

// Sayfa yüklendiğinde arama fonksiyonunu ve araç sayısını aktif et
document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('carSearchInput');
    const searchButton = document.getElementById('carSearchButton');

    // Arama fonksiyonu
    function filterCars() {
        const searchText = searchInput.value.toLowerCase();
        const carItems = document.querySelectorAll('.car-item-wrapper');
        let found = false;

        carItems.forEach(item => {
            const brand = item.getAttribute('data-brand');
            const model = item.getAttribute('data-model');
            const year = item.getAttribute('data-year');
            const fuelType = item.getAttribute('data-fueltype');
            const transmission = item.getAttribute('data-transmission');

            // Tüm data-* özniteliklerinde arama yap
            if (brand.includes(searchText) ||
                model.includes(searchText) ||
                year.includes(searchText) ||
                fuelType.includes(searchText) ||
                transmission.includes(searchText)) {
                item.style.display = '';
                found = true;
            } else {
                item.style.display = 'none';
            }
        });

        // Araç sayısı güncelleniyor
        updateCarCount();

        // Eğer araç bulunamazsa mesaj göster
        const carListContainer = document.getElementById('carListContainer');
        let noCarsMessage = document.getElementById('no-cars-found-alert');
        if (!noCarsMessage) {
            noCarsMessage = document.createElement('div');
            noCarsMessage.id = 'no-cars-found-alert';
            noCarsMessage.className = 'col-12 no-cars-found-message';
            noCarsMessage.innerHTML = `<div class="alert alert-info text-center" role="alert">No cars found matching your search criteria.</div>`;
            carListContainer.appendChild(noCarsMessage);
        }

        if (found) {
            noCarsMessage.style.display = 'none';
        } else {
            noCarsMessage.style.display = 'block';
        }
    }

    // Başlangıçta araç sayısını güncelle
    updateCarCount();

    searchButton.addEventListener('click', filterCars);
    searchInput.addEventListener('input', filterCars);
});
