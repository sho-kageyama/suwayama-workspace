/**
 *
 */
package jp.co.ginga.application.helper.facility;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Component;

import jp.co.ginga.application.form.facility.FacilityForm;
import jp.co.ginga.domain.entity.FacilityEntity;
import jp.co.ginga.domain.entity.FacilityTypeEntity;

/**
 * @author yoshi
 *
 */
@Component
public class FacilityHelper {

	/**
	 * FacilityEntityListからFacilityFormListへのコンバート処理
	 *
	 * @param list
	 * @return
	 */
	public List<FacilityForm> convertFromFacilityEntityListToFacilityFormList(List<FacilityEntity> list) {
		List<FacilityForm> convertList = new ArrayList<FacilityForm>();

		for (FacilityEntity entity : list) {

			convertList.add(convertFromFacilityEntityToFacilityForm(entity));
		}
		return convertList;
	}

	/**
	 * FacilityEntityからFacilityFormへのコンバート処理
	 *
	 * @param facility
	 * @return
	 */
	public FacilityForm convertFromFacilityEntityToFacilityForm(FacilityEntity facility) {
		return new FacilityForm(facility.getId(), facility.getName(), facility.getTypeId(), facility.getCapacity(), facility.getUserId());
	}

	/**
	 * FacilityFormからFacilityEntityへのコンバート処理
	 *
	 * @param facility
	 * @return
	 */
	public FacilityEntity convertEntityFacilityForm(FacilityForm session) {
		return new FacilityEntity(session.getId(), session.getName(), session.getTypeId(), session.getCapacity(), session.getUserId());
	}

	/**
	 * FacilityEntityListとFacilityTypeEntityListからFacilityFormListへのコンバート処理
	 *
	 * @param list
	 * @return
	 */
	public List<FacilityForm> convertFromFacilityEntityListAndFacilityTypeEntityListToFacilityFormList(List<FacilityEntity> facilityList , List<FacilityTypeEntity> typeList) {

		List<FacilityForm> formList  = new ArrayList<FacilityForm>();

		for(FacilityEntity facility : facilityList) {
			for(FacilityTypeEntity type : typeList) {
				if(facility.getTypeId() == type.getId()) {
					FacilityForm form = new FacilityForm(facility.getId(),facility.getName(),facility.getTypeId(),type.getName(),facility.getCapacity());
					formList.add(form);
				}
			}
		}

		return formList;
	}
}
