package jp.co.ginga.domain.service;

import java.util.List;

import jp.co.ginga.domain.entity.FacilityEntity;

/**
 * 施設サービス
 *
 * @author yoshi
 *
 */
public interface FacilityService {

	public FacilityEntity getFacility(int id);

	public List<FacilityEntity> getFacilityList();

	public int add(FacilityEntity facility);

	public int update(FacilityEntity facility);

	public int delete(int id);

}
