// wwwroot/Admin/vertical/assets/js/CarListScripts.js

document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('carSearchInput');
    // Search button artık event tetiklemek için değil, sadece input'un varlığını doğrulamak için gerekli olabilir.
    // const searchButton = document.getElementById('carSearchButton'); 
    const carItemWrappers = document.querySelectorAll('.car-item-wrapper');

    // Eğer arama input'u ve kartlar varsa, olay dinleyicilerini ekle
    if (searchInput && carItemWrappers.length > 0) {
        // Sadece input'a yazıldığında (keyup) arama yap
        searchInput.addEventListener('keyup', filterCars);

        // Opsiyonel: Input boşaldığında tüm listeyi göster (tekrar eski haline getir)
        searchInput.addEventListener('input', function () {
            if (searchInput.value.trim() === '') {
                // Boş arama durumunda tüm kartları göster
                carItemWrappers.forEach(itemWrapper => {
                    itemWrapper.classList.remove('d-none');
                });
            }
        });
    }

    function filterCars() {
        const searchTerm = searchInput.value.toLowerCase().trim();

        carItemWrappers.forEach(itemWrapper => {
            // data-* attribute'lerinden bilgileri al
            const brandData = itemWrapper.dataset.brand ? itemWrapper.dataset.brand.toLowerCase() : '';
            const modelData = itemWrapper.dataset.model ? itemWrapper.dataset.model.toLowerCase() : '';
            const yearData = itemWrapper.dataset.year ? itemWrapper.dataset.year.toLowerCase() : '';
            const typeData = itemWrapper.dataset.type ? itemWrapper.dataset.type.toLowerCase() : '';
            const fuelTypeData = itemWrapper.dataset.fueltype ? itemWrapper.dataset.fueltype.toLowerCase() : '';
            const transmissionData = itemWrapper.dataset.transmission ? itemWrapper.dataset.transmission.toLowerCase() : '';

            // Arama terimi ile eşleşme kontrolü
            const matchesSearchTerm =
                brandData.includes(searchTerm) ||
                modelData.includes(searchTerm) ||
                yearData.includes(searchTerm) ||
                typeData.includes(searchTerm) ||
                fuelTypeData.includes(searchTerm) ||
                transmissionData.includes(searchTerm);

            // Kartı göster veya gizle (Bootstrap'in d-none sınıfını kullanarak)
            if (matchesSearchTerm) {
                itemWrapper.classList.remove('d-none');
            } else {
                itemWrapper.classList.add('d-none');
            }
        });
    }
});