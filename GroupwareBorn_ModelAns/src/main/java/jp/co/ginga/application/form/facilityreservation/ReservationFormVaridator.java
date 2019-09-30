package jp.co.ginga.application.form.facilityreservation;

import java.text.ParseException;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.validation.Errors;
import org.springframework.validation.Validator;

import jp.co.ginga.application.helper.facilityreservation.FacilityReservationHelper;
import jp.co.ginga.domain.entity.FacilityReservationEntity;
import jp.co.ginga.domain.service.FacilityResevationService;

@Component
public class ReservationFormVaridator implements Validator {

	@Autowired
	FacilityResevationService reservationService;

	@Autowired
	FacilityReservationHelper helper;

	@Override
	public boolean supports(Class<?> clazz) {
		// TODO 自動生成されたメソッド・スタブ
		return ReservationForm.class.isAssignableFrom(clazz);
	}

	@Override
	public void validate(Object target, Errors errors) {
		ReservationForm reservation = (ReservationForm) target;
		try {
			FacilityReservationEntity reservationEntity = helper.formConvartEntity(reservation);

			if (reservationEntity.getId() == 0) {
				List<FacilityReservationEntity> duplicate = reservationService.checkDuplicate(reservationEntity);
				if (duplicate != null) {
					List<ReservationForm> formList = helper.entityConvartFormList(duplicate);
					System.out.println("Duplicate!! new");
					StringBuilder sb = new StringBuilder();
					for (ReservationForm form : formList) {
						errors.rejectValue("multiError", "duplicate.error.reservation",
								form.getStartTime() + "〜" + form.getEndTime() + "ですでに予約があります");
					}

				}
			} else {
				FacilityReservationEntity update = reservationService
						.getFacilityReservationById(reservationEntity.getId());

				if (reservationEntity.getStart_time() != update.getStart_time()
						&& reservationEntity.getEnd_time() != update.getEnd_time()) {
					List<FacilityReservationEntity> duplicate = reservationService.checkDuplicate(reservationEntity);
					if (duplicate != null) {
						List<ReservationForm> formList = helper.entityConvartFormList(duplicate);
						StringBuilder sb = new StringBuilder();
						for (ReservationForm form : formList) {
							errors.rejectValue("multiError", "duplicate.error.reservation",
									form.getStartTime() + "〜" + form.getEndTime() + "ですでに予約があります");
						}

					}
				}
			}
		} catch (ParseException e) {

			e.printStackTrace();
		}

	}

}
