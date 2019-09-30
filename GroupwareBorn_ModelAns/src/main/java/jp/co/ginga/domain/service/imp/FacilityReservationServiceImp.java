package jp.co.ginga.domain.service.imp;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import jp.co.ginga.application.form.facilityreservation.ReservationDetailForm;
import jp.co.ginga.domain.entity.FacilityReservationEntity;
import jp.co.ginga.domain.repository.FacilityReservationRepository;
import jp.co.ginga.domain.service.FacilityResevationService;

@Service
@Transactional
public class FacilityReservationServiceImp implements FacilityResevationService {

	@Autowired
	FacilityReservationRepository reservationRep;

	@Override
	public List<ReservationDetailForm> getFacilityReservationList(int facilityId, int year, int month) {
		String yearMonth = String.valueOf(year) + "-" + String.valueOf(month);
		return reservationRep.facilityReservation(facilityId, yearMonth);
	}

	@Override
	public FacilityReservationEntity getFacilityReservationById(int id) {
		// TODO 自動生成されたメソッド・スタブ
		return reservationRep.findOne(id);
	}

	@Override
	public int AddReservation(FacilityReservationEntity reservationEntity) {
		// TODO 自動生成されたメソッド・スタブ
		if (reservationRep.insert(reservationEntity)) {
			return 1;
		}
		return 0;
	}

	@Override
	public int UpdateReservation(FacilityReservationEntity reservationEntity) {
		// TODO 自動生成されたメソッド・スタブ
		if (reservationRep.update(reservationEntity)) {
			return 1;
		}
		return 0;
	}

	@Override
	public int DeleteReservation(int id) {
		// TODO 自動生成されたメソッド・スタブ
		if (reservationRep.delete(id)) {
			return 1;
		}
		return 0;
	}

	@Override
	public List<FacilityReservationEntity> checkDuplicate(FacilityReservationEntity reservationEntity) {
		// TODO 自動生成されたメソッド・スタブ
		return reservationRep.checkDuplicate(reservationEntity);
	}

}
