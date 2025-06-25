(function ($) {

	"use strict";

	var fullHeight = function () {
		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function () {
			$('.js-fullheight').css('height', $(window).height());
		});
	};
	fullHeight();

	// Sayfa y�klenince sidebar durumunu kontrol et
	if (localStorage.getItem('sidebarState') === 'closed') {
		$('#sidebar').addClass('active'); // Kapal� ise 'active' class ekle
	}

	// Butona t�klan�nca class de�i�tir ve durumu kaydet
	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');
		if ($('#sidebar').hasClass('active')) {
			localStorage.setItem('sidebarState', 'closed');
		} else {
			localStorage.setItem('sidebarState', 'open');
		}
	});

})(jQuery);


