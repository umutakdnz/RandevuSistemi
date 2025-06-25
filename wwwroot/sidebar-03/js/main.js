(function ($) {

	"use strict";

	var fullHeight = function () {
		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function () {
			$('.js-fullheight').css('height', $(window).height());
		});
	};
	fullHeight();

	// Sayfa yüklenince sidebar durumunu kontrol et
	if (localStorage.getItem('sidebarState') === 'closed') {
		$('#sidebar').addClass('active'); // Kapalý ise 'active' class ekle
	}

	// Butona týklanýnca class deðiþtir ve durumu kaydet
	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');
		if ($('#sidebar').hasClass('active')) {
			localStorage.setItem('sidebarState', 'closed');
		} else {
			localStorage.setItem('sidebarState', 'open');
		}
	});

})(jQuery);


