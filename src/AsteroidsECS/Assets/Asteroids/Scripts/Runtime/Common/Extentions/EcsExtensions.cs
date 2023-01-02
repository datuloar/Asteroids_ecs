using Leopotam.EcsLite;


public static class EcsExtensions
{
    public static void AddNewEntityWith<TComponent>(this EcsWorld world) where TComponent : struct
    {
        var entity = world.NewEntity();
        var pool = world.GetPool<TComponent>();
        pool.Add(entity);
    }

    public static int AddNewEntityWith<TComponent>(this EcsWorld world, TComponent value) where TComponent : struct
    {
        var entity = world.NewEntity();
        world.AddComponent(entity, value);

        return entity;
    }

    public static void AddComponent<TComponent>(this EcsWorld world, int id, TComponent component) where TComponent : struct
    {
        var pool = world.GetPool<TComponent>();
        pool.Add(id);
        ref var reference = ref pool.Get(id);
        reference = component;
    }

    public static void AddComponent<TComponent>(this EcsWorld world, int id) where TComponent : struct
    {
        var pool = world.GetPool<TComponent>();
        pool.Add(id);
    }

    public static ref T GetOrAddComponent<T>(this EcsWorld world, int entity) where T : struct
    {
        var pool = world.GetPool<T>();
        if (pool.Has(entity))
            return ref pool.Get(entity);

        return ref pool.Add(entity);
    }

    public static ref T GetOrAddComponent<T>(this IEcsSystems systems, int entity) where T : struct
    {
        return ref GetOrAddComponent<T>(systems.GetWorld(), entity);
    }

    public static ref T GetOrAddComponent<T>(this EcsPool<T> pool, int entity) where T : struct
    {
        if (pool.Has(entity))
            return ref pool.Get(entity);

        return ref pool.Add(entity);
    }

    public static bool TryGetComponent<T>(this EcsWorld world, int entity, out T component) where T : struct
    {
        if (world.GetPool<T>().Has(entity))
        {
            ref var c = ref world.GetPool<T>().Get(entity);
            component = c;
            return true;
        }
        component = default;
        return false;
    }

    public static bool TryGetComponent<T>(this IEcsSystems systems, int entity, out T component) where T : struct
    {
        return TryGetComponent<T>(systems.GetWorld(), entity, out component);
    }

    public static bool TryGetComponent<T>(this EcsPool<T> pool, int entity, out T component) where T : struct
    {
        if (pool.Has(entity))
        {
            component = pool.Get(entity);
            return true;
        }
        component = default;
        return false;
    }

    public static void ChangeOrAddComponent<TComponent>(this EcsWorld world, int id, TComponent component) where TComponent : struct
    {
        var pool = world.GetPool<TComponent>();

        if (pool.Has(id))
        {
            ref var reference = ref pool.Get(id);
            reference = component;
        }
        else
        {
            world.AddComponent(id, component);
        }
    }
}