package jp.co.ginga.domain.repository;

import java.util.List;

import org.apache.ibatis.annotations.Delete;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Options;
import org.apache.ibatis.annotations.Select;
import org.apache.ibatis.annotations.Update;
import org.springframework.stereotype.Repository;

import jp.co.ginga.domain.entity.FacilityEntity;

/**
 * 施設テーブルRepository
 * @author yoshi
 *
 */
@Mapper
@Repository
public interface FacilityRepository {

	/**
	 * 施設IDによる1件検索処理
	 *
	 * @param id
	 * @return
	 */
	@Select("select id,name,type_id as typeId,capacity,insert_date as insertDate,update_date as updateDate,user_id as userId from facility where id=#{id}")
	public FacilityEntity findOneById(int id);

	/**
	 * 施設全件検索処理
	 *
	 * @return
	 */

	@Select("select id,name,type_id as typeId,capacity,insert_date as insertDate,update_date as updateDate,user_id as userId from facility")
	public List<FacilityEntity> findAll();

	/**
	 * 施設新規登録処理
	 */
	@Insert("insert into facility (name,type_id,capacity,insert_date,user_id) values (#{name},#{typeId},#{capacity},now(),#{userId}) ")
	@Options(useGeneratedKeys = true, keyProperty = "id")
	public boolean add(FacilityEntity facility);

	/**
	 * 施設更新処理
	 */
	@Update("update facility set name = #{name}, type_id = #{typeId}, capacity = #{capacity}, update_date = now(),user_id = #{userId} where id = #{id}")
	public boolean update(FacilityEntity facility);

	/**
	 * 施設削除処理
	 */
	@Delete("delete from facility where id = #{id}")
	public boolean delete(int id);
}
